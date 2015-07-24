﻿[CmdletBinding()]
param(
    [ValidateNotNullOrEmpty()]
    [string] $projectCollection,

    [ValidateNotNullOrEmpty()]
    [string] $project,

    [ValidateNotNullOrEmpty()]
    [string] $build,
    
    [ValidateNotNullOrEmpty()]
    [string] $buildNumber,

    [ValidateNotNullOrEmpty()]
    [string] $user,

    [ValidateNotNullOrEmpty()]
    [string] $reason
)

Write-Verbose "Invoke-Tests: param projectCollection = $projectCollection"
Write-Verbose "Invoke-Tests: param project = $project"
Write-Verbose "Invoke-Tests: param build = $build"
Write-Verbose "Invoke-Tests: param buildNumber = $buildNumber"
Write-Verbose "Invoke-Tests: param user = $user"
Write-Verbose "Invoke-Tests: param reason = $reason"

$ErrorActionPreference = 'Stop'

$commonParameterSwitches =
    @{
        Verbose = $PSBoundParameters.ContainsKey('Verbose');
        Debug = $PSBoundParameters.ContainsKey('Debug');
        ErrorAction = "Stop"
    }

$content = "All your fake tests have passed!"
Set-Content -Path "\\tfsbuilds\tfsbduilds\$($build)\$($buildNumber)\testresult.txt" -Force

$reasonText = [System.IO.File]::ReadAllText((Join-Path $PSScriptRoot $buildNumber))

$idRegex = '^(?:Requested\s*by\s*pipeline:)\s*(?:Issue:\s*)(.*)'
if (-not ($reasonText -match $idRegex))
{
    throw "$reasonText does not match the expected build comment of 'Requested by pipeline: Issue: XXXXXX'"
}

$id = [regex]::Replace($reasonText, $idRegex, '$1')

$url = "http://vlt163:7070/api/signal/"

$content = @"
{
    "Type" : "TestComplete",
    "ProjectCollection" : "$projectCollection",
    "Project" : "$project",
    "Id" : "$id",
    "Result" : "Issue status: Approve: Pipeline"
}
"@

Write-Verbose "Sending release data to $url with JSON body:"
Write-Verbose $content
$response = Invoke-WebRequest -Method Post -Uri $url -Body $content -Header $headers -ContentType 'application/json' -UseBasicParsing

# PowerShell example: subscribe to WinEvent for image load/process start
# Run in an isolated test VM. This is for monitoring and logging only.
$Query = @"
<QueryList>
  <Query Id="0" Path="Microsoft-Windows-Kernel-Image/Operational">
    <Select Path="Microsoft-Windows-Kernel-Image/Operational">*[System]</Select>
  </Query>
</QueryList>
"@

Register-WinEvent -Query $Query -SourceIdentifier "ImageLoadMonitor" -Action {
    param($Event)
    $msg = $Event.Message
    Write-Output "[ImageLoad] $msg"
}

Write-Output "Listener registered. Press Enter to unregister."
Read-Host
Unregister-Event -SourceIdentifier "ImageLoadMonitor"

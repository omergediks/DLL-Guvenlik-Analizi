# DLL Analysis & Monitoring Project (Academic, Defensive)

This project contains defensive monitoring and analysis tools for DLL load and process memory behavior.
All code is intended for **research, defensive, and educational** purposes only. **Do not** use the code to perform attacks or abuse systems.

## Contents
- Thesis.md / Thesis.pdf : 10-page academic writeup (defensive, non-actionable).
- CSharp/MemoryMonitor.cs : Safe memory region scanner (uses VirtualQueryEx) for analysis.
- CSharp/DllLoadListener.cs : Simple ETW-like EventListener snippet for image load events (managed).
- Python/etw_listener.py : Example ETW listener using `krabsetw` wrapper (requires krabsetw or similar).
- PowerShell/kernel_logger.ps1 : Example script for collecting process/image load events via WMI/EventLog.
- LICENSE : MIT (for educational use).

## Usage
- Review code and run only inside an isolated test VM you control.
- Do not deploy any kernel-level components to production systems without vendor-grade testing.

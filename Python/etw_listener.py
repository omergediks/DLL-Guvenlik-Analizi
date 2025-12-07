# ETW listener example (requires krabsetw or similar ETW wrapper)
# This script demonstrates subscribing to ImageLoad events for monitoring purposes.
# For real experiments run inside an isolated VM and install krabsetw (https://github.com/microsoft/krabsetw).

try:
    import krabsetw
except Exception as e:
    print("krabsetw not installed. Install it in your environment to run ETW capture. Error:", e)
    # Fallback: print a note and exit
    raise SystemExit(1)

def on_event(record):
    try:
        print("[ETW]", record.name, record.payload)
    except Exception as e:
        print("Event handler error:", e)

def main():
    session = krabsetw.Session(handler=on_event, name="dll-monitor-session")
    provider = krabsetw.Provider(name="Microsoft-Windows-Kernel-Image", event_id=1)  # Image load provider
    session.add_provider(provider)
    session.start()
    print("ETW session started; press Ctrl+C to stop")
    try:
        while True:
            pass
    except KeyboardInterrupt:
        session.stop()
        print("Session stopped")

if __name__ == '__main__':
    main()

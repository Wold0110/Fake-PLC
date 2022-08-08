# Modbus Project
This solution contains multiple projects, here's the list:

## Fake PLC
- Contains 65535 read/write registers
- Docker support
- Runs on **port 502**

## Modbus Reader
- Read/Write register
- Handle multiple register on different devices
- Auto refresh register content in adjustable interval

## PLC Transferer
- copy data between PLCs
- from (ip,port,address) | length | to (ip,port,address)

## Error Translator
- adjust an error code range to a single zeroed out register

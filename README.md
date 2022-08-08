# Modbus Project
This solution contains multiple projects, here's the list:
Uses [EasyModbusTCP .NET](http://easymodbustcp.net/en/) implementation
## Fake PLC
- Contains *65535* read/write registers
- [Docker support](https://hub.docker.com/r/wolf0110/fakeplc): `docker run -d -p 502:502 wolf0110/fakeplc`
- Runs on port `502` by default

## Modbus Reader
- GUI tool to handle ModbusTCP
- Read/Write registers
- Handle multiple registers on different devices
- Auto refresh register content in adjustable interval

## PLC Transferer
- copy data between PLCs
- from (ip,port,address) | length | to (ip,port,address)

## Error Translator
- transform an error code range to a single zeroed out register

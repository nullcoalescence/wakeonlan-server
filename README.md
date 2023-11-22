# wakeonlan-server
This is a simple ASP.NET Core MVC app for sending magic packets to home network devices to wake em on lan.

The idea is for this to be a lightweight application that can run on an always-on network device, like a Raspberry Pi.
If you aren't home and need to remotely access a PC that is off, you can VPN back into your home network, send an HTTP POST to `http://raspberry-pi/wakeonlan-server/wake/my-pc` which will fire off a magic packet to the specified device.

## Build
Building a dev environment involves cloning the repo and running the database migrations for the sqlite db.
```
$ git clone https://github.com/nullcoalescence/wakeonlan-server
$ cd wakeonlan-server
$ dotnet ef database update
$ dotnet run
```
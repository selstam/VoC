# VoC
Volvo on Call API implementation

VoC retrieves information from Volvo on Call services using a command line interface with json or table output.

```
Volvo on Call, voc, version 1.0.0

Usage: voc [options] [command]

Options:
  --version                 Show version information
  --help                    Show help information
  -u|--username <username>  Volvo on Call Username (i.e. email address).
  -p|--password <password>  Volvo on Call Password.
  -i|--vin <number>         Your Volvo's VIN number.
  --server <fqdn>           Volvo on Call service server.
  -b|--beautify             Beautify Json output.
  -t|--table                Output as table (not all data returned).
  -o|--omit                 Omit key when using filters.

Commands:
  attributes                Gets car's technical attributes.
  lock                      Locks your car.
  unlock                    Unlocks your car.
  position                  Gets car's last reported GPS position.
  status                    Gets car's last reported status.
  trips                     Gets car's driving journal.

Run 'voc [command] --help' for more information about a command.
```

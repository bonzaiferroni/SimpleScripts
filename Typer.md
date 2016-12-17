# Typer
Simple script for typing animations

## Suggested use
Drop this onto a gameObject, change Messages size to some value greater than 0. Duration value determines how long the message will be displayed.

## Examples

#### Adding new messages at runtime 

```c#
var typer = FindObjectOfType<Typer>();
typer.Messages.Add(new TyperMessage("there's a snake in my boot", 5));
```

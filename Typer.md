# Typer.cs
> Simple script for typing animations

* [Link to file](https://github.com/bonzaiferroni/SimpleScripts/edit/master/Typer.cs)
* [Link to album](http://imgur.com/a/AkrmH)
* [Link to discussion](https://www.reddit.com/r/Unity3D/comments/5iwroh/typercs_simple_script_for_displaying_a_typing/?st=iwtquqgd&sh=74a9a672)

### Suggested use
Drop this onto a gameObject, change `Messages` size to some value greater than 0. `Duration` value determines how long the message will be displayed.

### Examples

#### Adding new messages at runtime 

    var typer = FindObjectOfType<Typer>();
    typer.Messages.Add(new TyperMessage("there's a snake in my boot", 5));


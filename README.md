  # IN DEVELOPMENT

# AquaScript (WEB SECTION) 

Hosting documentation for AquaScript (WEB)

AquaScript is not just for web!

---

## Download

[Download AquaScript](https://github.com/Megamer-studios/AquaScript/releases/tag/PreRelease-Web)

---

### Example script

```
hidecli
// Hides the command interface
clear-usrvars
// Clears user variables 
$button Add
// Declares the 1st user variable(button) with the text "Add"
$button Subtract
// Declares the 2nd user variable(button) with the text "Subtract"
$button Divide
// Declares the 3rd user variable(button) with the text "Divide"
$button Multiply
// Declares the 4th user variable(button) with the text "Multiply"
$label Result:
// Declares the 5th user variable(label) with the text "Result"
$input 0
// Declares the 6th user variable(input) with the text "0"
$input 0
// Declares the 7th user variable(input) with the text "0"
$b-0 out add {$5} {$6}; $l-4 Result: {out};
// Sets the 1st user variable(button)'s click property to -
// runs the 'out' command setting the output variable to the result of the 'add'  command
// using the text from the 6th(input) and 7th(input) user variables
// (-1 in the code because index starts from 0)
// and then sets the text of the 5th user variable(label) to "Result: " + the output variable
$b-1 out sub {$5} {$6}; $l-4 Result: {out};
// Sets the 2nd user variable(button)'s click property to -
// runs the 'out' command setting the output variable to the result of the 'sub'  command
// using the text from the 6th(input) and 7th(input) user variables
// (-1 in the code because index starts from 0)
// and then sets the text of the 5th user variable(label) to "Result: " + the output variable
$b-2 out div {$5} {$6}; $l-4 Result: {out};
// Sets the 2nd user variable(button)'s click property to -
// runs the 'out' command setting the output variable to the result of the 'div'  command
// using the text from the 6th(input) and 7th(input) user variables
// (-1 in the code because index starts from 0)
// and then sets the text of the 5th user variable(label) to "Result: " + the output variable
$b-3 out mul {$5} {$6}; $l-4 Result: {out};
// Sets the 2nd user variable(button)'s click property to -
// runs the 'out' command setting the output variable to the result of the 'mul'  command
// using the text from the 6th(input) and 7th(input) user variables
// (-1 in the code because index starts from 0)
// and then sets the text of the 5th user variable(label) to "Result: " + the output variable
basicform Calculator^Sigma 500 500 vars
// Creates a 'basicform' 
// Sets the window title to 'Calculator Sigma' " (^) is replaced by a space in the code"
// sets the width to 500 pixels
// sets the height to 500 pixels
// 'vars' tells the window to include the user variables in the controls
showcli
// unhides the command interface
clear-usrvars
// clears the user variables
```

---

### How to run it:

1) Run the exe

2) Enter the command `runscript-web {ip}/index.asq`

---

## Server architecture

#### index.asq - main page

#### env.asv - program definition

#### about.asq - about page

---

## Definition structure

#### IP

#### Name

#### Author

#### Version

#### Description

---

## Definition example

```
http://192.168.1.131
AquaHosted
Akumarin Kukino
EARLY PROTOTYPE
A simple script environment hosted on Apache.
```

---

## Hosting

You can just host it on Apache. It doesn't matter just make the files accessible through the web server.

---

```
 Copyright (c) 2026 AquaScript. All rights reserved. - Akumarin Kukino - Megamer Studios
```

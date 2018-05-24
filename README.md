# Rock Paper Scissors Boom

Rock Paper Scissors Boom is a collaborative competition among developers. It's based on a project idea from a Microsoft Developer Evangelist that was called "Rock Paper Azure". Unlike that project, we are not going to require that you program on Azure, however, it will be an option.

This server project provides an API that developers can use to develop bots that play the Rock Paper Sissors Boom game.

## Rules of the Game

 * A match is played between two bots and will consist of 1000 rounds of Rock-Paper-Scissors
 * Rock beats Scissors
 * Scissors beats Paper
 * Paper beats Rock
 * A bomb will defeat Rock, Paper, or Scissors played by the opponent.
 * A water balloon will defeat a bomb.
 * Rock, Paper, and Scissors all beat water balloon.
 * Each bot receives 100 bombs to use during a match.
 * All matching choices will be a tie with the same choice by opponent.
 * Each bot may also throw a water balloon whenever it likes.

![game uml][game_diagram]

[game_diagram]:(docs/game_diagram.png)
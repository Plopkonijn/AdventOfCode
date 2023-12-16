﻿using TheFloorWillBeLava;

string[] text = File.ReadAllLines("input.txt");
var contraption = new Contraption(text);
var beam = new Beam(0, 0, 1, 0);

int answerPartOne = contraption.CountEnergizedTiles(beam);
Console.WriteLine(answerPartOne);
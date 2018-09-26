


The Problem
===========

Write a program that lets the user generate a shape with the dimensions of their choosing using a semi-natural language interface. Your solution has to have two components – a “front-end” and a “back-end”.



User Story
===========

As a user I want to generate shapes with natural language so that I don’t have to enter values in boxes



Acceptance Criteria
====================

The user should specify what to draw using natural language. To keep things simple, we’ll fix the allowed format to the following: 

Draw a(n) <shape> with a(n) <measurement> of <amount> (and a(n) <measurement> of <amount>)



Sample input strings
=====================

Draw a circle with a radius of 100

Draw a square with a side length of 200

Draw a rectangle with a width of 400 and a height of 150

Draw an isosceles triangle with a height of 200 and a width of 100

Draw a scalene triangle with a side lengths of 250 and 100 and 250

Draw a parallelogram with a side length of 150

Draw an equilateral Triangle with a side length of 100

Draw an oval with a width of 100 and a height of 50

Draw an octagon with a side length of 100

Draw a pentagon with a side length of 100

Draw a hexagon with a side length of 100

Draw a heptagon with a side length of 100



Conditions and rules
====================


for scalene triangle
---------------------

    (Side length1 + Sidelength2) > Sidelength3

         and

    (Sidelength1 + Sidelength3) > Sidelength2

         and

    (Sidelength2 + Sidelength3) > Sidelength1

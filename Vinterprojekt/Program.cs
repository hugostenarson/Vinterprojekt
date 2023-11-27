using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Raylib_cs;

Raylib.InitWindow(800,600,"Escape the Maze");
Raylib.SetTargetFPS(60);

Vector2 movement = new Vector2(2, 1);
float speed = 5;
string scene = "start";

Rectangle personRect = new Rectangle(10, 100, 25, 25);

Texture2D person = Raylib.LoadTexture("person.png");

List<Rectangle> walls = new();

walls.Add(new Rectangle(52, 32, 686, 32));
walls.Add(new Rectangle(82, 32, 32, 486));
walls.Add(new Rectangle(128, 32, 32, 128));
walls.Add(new Rectangle(128, 32, 128, 32));
walls.Add(new Rectangle(32, 232, 128, 32));
walls.Add(new Rectangle(32, 282, 32, 128));

while (!Raylib.WindowShouldClose())
{

movement = Vector2.Zero;
if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
{
    movement.Y = -1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_S))
{
    movement.Y = 1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_A))
{
    movement.X = -1;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
{
    movement.X = 1;
}

    if (movement.Length() > 0)
{
    movement = Vector2.Normalize(movement) * speed;
}
personRect.x += movement.X;
personRect.y += movement.Y;

if (personRect.x > 775)
{
    personRect.x = 775;
}

if (personRect.x < 0)
{
    personRect.x = 0;
}

if (personRect.y > 575)
{
    personRect.y = 575;
}

if (personRect.y < 0)
{
    personRect.y = 0;
}

Raylib.BeginDrawing();
Raylib.ClearBackground(Color.VIOLET);
// Raylib.DrawRectangleRec(personRect, Color.BLACK);
Raylib.DrawTexture(person, (int)personRect.x, (int)personRect.y, Color.WHITE);
foreach(Rectangle wall in walls)
    {
        Raylib.DrawRectangleRec(wall, Color.BLACK);
    }
    
Raylib.EndDrawing();
}
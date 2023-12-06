using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Raylib_cs;

Raylib.InitWindow(800,600,"Escape the Maze");
Raylib.SetTargetFPS(60);

Vector2 movement = new Vector2(2, 1);
float speed = 3;
string scene = "start";

Rectangle personRect = new Rectangle(10, 130, 25, 25);
Rectangle doorRect = new Rectangle(659, 70, 50, 50);


Texture2D person = Raylib.LoadTexture("person.png");

List<Rectangle> walls = new();
//Horisontella väggar
walls.Add(new Rectangle(52, 32, 686, 32));
walls.Add(new Rectangle(52, 232, 72, 32));
walls.Add(new Rectangle(178, 307, 107, 32));
walls.Add(new Rectangle(128, 317, 82, 32));
walls.Add(new Rectangle(52, 407, 80, 32));
walls.Add(new Rectangle(278, 130, 262, 32));
walls.Add(new Rectangle(348, 220, 132, 32));

//Vertikala väggar
walls.Add(new Rectangle(52, 32, 32, 72));
walls.Add(new Rectangle(52, 232, 32, 486));
walls.Add(new Rectangle(178, 32, 32, 128));
walls.Add(new Rectangle(178, 203, 32, 307));
walls.Add(new Rectangle(178, 551, 32, 69));
walls.Add(new Rectangle(253, 32, 32, 339));
walls.Add(new Rectangle(253, 414, 32, 189));
walls.Add(new Rectangle(448, 220, 32, 380));
walls.Add(new Rectangle(540, 32, 32, 468));
walls.Add(new Rectangle(540, 552, 32, 48));
walls.Add(new Rectangle(716, 32, 32, 568));



while (!Raylib.WindowShouldClose())
{

foreach(Rectangle wall in walls)
{
if (Raylib.CheckCollisionRecs(personRect, wall))
{
Raylib.DrawText("HIT!",500, 300, 32, Color.BLACK);
personRect.x = 10;
personRect.y = 130;
}
}

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
Raylib.DrawRectangleRec(doorRect, Color.PURPLE);
Raylib.DrawText("Here!", 665, 87, 15, Color.WHITE);
foreach(Rectangle wall in walls)
    {
        Raylib.DrawRectangleRec(wall, Color.BLACK);
    }
    
Raylib.EndDrawing();
}
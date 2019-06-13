<template>
    <div v-if="this.GameIsOn == false"><button v-on:click="StartUp()">Jouer</button></div>
    <div v-else class="Game"></div>
</template>

<script>
import * as PIXI from "pixi.js";
//import Vuex from "vuex";

export default {
  computed: {
  },
  data() {

    return {

      Score: 0,
      Arena: {},
      i: 0,
      GameIsOn: false,
      app,
      textures
    }
  },
  methods: {

    End: function() {

    },

    GameLoop: function(delta) {

        while (this.IsDead() == false) {

            this.MoveSnake();

            if (this.IsFoodEated() == true) {

                this.GrowUp();
                this.SpawnFood();
            }
        }

        this.End();
    },

    StartUp: function() {

        debugger;

        this.Score = 0;
        this.GameIsOn = true;

        this.app = new PIXI.Application({ 
            width: 400,         // default: 800
            height: 400,        // default: 600
            antialias: true,    // default: false
            transparent: false, // default: false
            resolution: 1       // default: 1
        });
        this.app.renderer.backgroundColor = 0x061639; //BackGround Color

        this.textures = new PIXI.Container();

        this.createSnake();
        this.createFood();

        this.app.addChild(this.textures);

        document.querySelector('.Game').appendChild(this.app.view);

        this.app.renderer.render(this.app.stage);

        this.Arena = {
            Snake: {},
            Food: {}
        }

        this.SpawnSnake();
        this.SpawnFood();

        this.app.ticker.add(delta => This.GameLoop(delta));
    },

    createSnake: function() {

        let snake = PIXI.Sprite.fromImage("@/games/Snake/snake.png");
        this.textures.addChild(snake);
    },

    createFood: function() {

        let food = PIXI.Sprite.fromImage("@/games/Snake/food.png");
        this.textures.addChild(food);
    },

    SpawnFood: function() {

        this.Arena.Food = {

            X: Math.floor(Math.random()*10),
            Y: Math.floor(Math.random()*10)
        }
        //this.textures.food.x = this.Arena.Food.X + 1;
        //this.textures.food.y = this.Arena.Food.Y + 1;
    },

    SpawnSnake: function() {

        this.Arena.Snake = {
            Direction: Math.floor(Math.random()*4),
            Tail: [
                {
                    X: Math.floor(Math.random()*10),
                    Y: Math.floor(Math.random()*10),
                    Exist: true
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                },
                {
                    X: 0,
                    Y: 0,
                    Exist: false
                }
            ]
        }
        //this.textures.snake.x = this.Arena.Snake.Tail[0].X + 1;
        //this.textures.snake.y = this.Arena.Snake.Tail[0].Y + 1;
    },

    MoveSnake: function() {

        if (KeyboardEvent.up) {

            this.Arena.Snake.Direction = 0;
        } 
        else if (KeyboardEvent.right) {

            this.Arena.Snake.Direction = 1;
        } 
        else if (KeyboardEvent.left) {

            this.Arena.Snake.Direction = 2;
        } 
        else if (KeyboardEvent.down) {

            this.Arena.Snake.Direction = 3;
        }

        for (this.i=9; this.i >= 0; this.i--) {

            if (this.Arena.Snake.Tail[this.i].Exist && this.i != 0) {

                this.Arena.Snake.Tail[this.i].X = this.Arena.Snake.Tail[this.i-1].X;
                this.Arena.Snake.Tail[this.i].Y = this.Arena.Snake.Tail[this.i-1].Y;
            }
        }

        if (this.Arena.Snake.Direction == 0) {

            this.Arena.Snake.Tail[0].Y--;
            //this.textures.snake.y--;
        }
        else if (this.Arena.Snake.Direction == 1) {

            this.Arena.Snake.Tail[0].X++;
            //this.textures.snake.x++;
        }
        else if (this.Arena.Snake.Direction == 2) {

            this.Arena.Snake.Tail[0].Y++;
            //this.textures.snake.y++;
        }
        else if (this.Arena.Snake.Direction == 3) {

            this.Arena.Snake.Tail[0].X--;
            //this.textures.snake.x--;
        }
    },

    IsFoodEated: function() {

        if (this.Arena.Snake.Tail[0].X == this.Arena.Food.X 
        &&  this.Arena.Snake.Tail[0].Y == this.Arena.Food.Y) {

            return true;
        }
        else {

            return false;
        }
    },

    IsDead: function() {

        if (this.Arena.Snake.Tail[0].X < 0
        ||  this.Arena.Snake.Tail[0].X > 9
        ||  this.Arena.Snake.Tail[0].Y < 0
        ||  this.Arena.Snake.Tail[0].Y > 9) {

            return true;
        }
        else {

            for (this.i = 1; this.i < 10; this.i++) {

                if (this.Arena.Snake.Tail[this.i].Exist == true
                &&  this.Arena.Snake.Tail[0].X == this.Arena.Snake.Tail[this.i].X
                &&  this.Arena.Snake.Tail[0].Y == this.Arena.Snake.Tail[this.i].Y) {

                    return true;
                }
                else {

                    return false;
                }
            }
        }
    },

    GrowUp: function() {

        this.i = 1;
        while (this.Arena.Snake.Tail[this.i].Exist == true) {

            this.i++;
        }

        this.Score++;
        this.Arena.Snake.Tail[this.i].Exist = true;
    }
  }
};
</script>
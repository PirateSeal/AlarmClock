<template>
    <div id='Game'>
    </div>
</template>

<script>
import * as PIXI from 'pixi.js';
import vue from 'vue';

export default {
  computed: {
  },
  data() {

    return {

      Score: 0,
      Arena: {},
      app: {},
      container: {},
      GameIsOn: false,
      snake: [],
      food: {},
      texte: "",
      Divisor: 0,
      Time: this.$route.params.Time
    }
  },

  async mounted() {

    window.addEventListener("keydown", this.ChangeDirection);
    this.StartUp();
  },

  destroy() {

      window.removeEventListener("keydown", this.ChangeDirection);
  },

  methods: {

    End: function() {

        this.$router.replace("/EndGame/" + this.Score + "/10/" + this.Time);
        GameIsOn = false;
    },

    GameLoop: function(delta) {

        this.Arena.LifeTime++;

        for ( let i = 0 ; i < 20 ; i++) {

            if (this.snake[i] != null) {

                this.snake[i].x = (this.Arena.Snake.Tail[i].X + 1) * 20;
                this.snake[i].y = (this.Arena.Snake.Tail[i].Y + 1) * 20;
            }
        }
        this.food.x = (this.Arena.Food.X + 1) * 20;
        this.food.y = (this.Arena.Food.Y + 1) * 20;
        
        if (this.Arena.LifeTime % this.Arena.WaitTime == 0) {
            if (!this.IsDead()) {

                if (this.IsFoodEated()) {

                    this.GrowUp();
                    this.SpawnFood();

                    if (this.Score > 20) {

                        this.Divisor = 3;

                    } else if (this.Score > 15) {

                        this.Divisor = 2;

                    } else if (this.Score > 10) {

                        this.Divisor = 1;

                    }  

                    if (this.Score > 9) {

                        if (this.Score%this.Divisor == 0) 
                        {
                            this.Arena.WaitTime -= 1;
                        }
                        this.Arena.LifeTime = 0;
                    }
                }

                this.MoveSnake();
                if (this.Arena.Snake.Direction == 0) {

                    this.Arena.Snake.Tail[0].Y--;
                    this.snake[0].y -= 20;
                }
                else if (this.Arena.Snake.Direction == 1) {

                    this.Arena.Snake.Tail[0].X++;
                    this.snake[0].x += 20;
                }
                else if (this.Arena.Snake.Direction == 3) {

                    this.Arena.Snake.Tail[0].Y++;
                    this.snake[0].y += 20;
                }
                else if (this.Arena.Snake.Direction == 2) {

                    this.Arena.Snake.Tail[0].X--;
                    this.snake[0].x -= 20;
                }
            } 
            else {

                this.End();
            } 
        }
    },

    StartUp: function() {

        

        this.Score = 0;
        this.GameIsOn = true;

        this.app = new PIXI.Application({
            width: 640,
            height: 674, 
            backgroundColor: 0x1099bb, 
            resolution: window.devicePixelRatio || 1,
        });

        document.querySelector("#Game").appendChild(this.app.view);

        this.container = new PIXI.Container();

        this.app.loader.add('snake', '/Snake/snake.png');

        this.app.loader.add('food', '/Snake/food.png');

        let style = new PIXI.TextStyle({
            fontFamily: "Arial",
            fontSize: 25,
            fill: "white",
            stroke: '#ff3300',
            strokeThickness: 4,
            dropShadow: true,
            dropShadowColor: "#000000",
            dropShadowBlur: 4,
            dropShadowAngle: Math.PI / 6,
            dropShadowDistance: 6,
        });

        this.texte = new PIXI.Text("Score : " + this.Score, style);
        this.texte.position.set(5, 642);

        this.app.stage.addChild(this.texte);

        let line = new PIXI.Graphics();
        line.lineStyle(4, 0xFFFFFF, 1);
        line.moveTo(0, 642);
        line.lineTo(640, 642);

        this.app.stage.addChild(line);

        this.app.loader.load((loader, resources) => {

            this.snake[0] = new PIXI.Sprite(resources.snake.texture);

            this.snake[0].width = 20;
            this.snake[0].height = 20;
            this.snake[0].z = 1;

            this.food = new PIXI.Sprite(resources.food.texture);

            this.food.width = 20;
            this.food.height = 20;
            this.food.z = 2;

            this.container.addChild(this.snake[0]);
            this.container.addChild(this.food);

            this.Arena = {
                Snake: {},
                Food: {},
                LifeTime : 0,
                WaitTime: 12
            }

            this.SpawnSnake();
            this.SpawnFood();

            this.app.stage.addChild(this.container);

            this.app.renderer.render(this.app.stage);

            this.app.ticker.add(delta => this.GameLoop(delta));
        });
        

        

        //debugger;
        
    },

    SpawnFood: function() {

        this.Arena.Food = {

            X: Math.floor(Math.random()*30),
            Y: Math.floor(Math.random()*30)
        }
    },

    SpawnSnake: function() {

        this.Arena.Snake = {
            Direction: Math.floor(Math.random()*4),
            Tail: [
                {X: 15, Y: 15, Exist: true},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false},
                {X: 0, Y: 0, Exist: false}
            ]
        }
        this.snake[0].x = this.Arena.Snake.Tail[0].X + 1;
        this.snake[0].y = this.Arena.Snake.Tail[0].Y + 1;
    },

    ChangeDirection(e) {
        console.log(e);
        if (e.key == "ArrowUp" && this.Arena.Snake.Direction != 0 && this.Arena.Snake.Direction != 3) {

            this.Arena.Snake.Direction = 0;
        } 
        else if (e.key == "ArrowRight" && this.Arena.Snake.Direction != 1 && this.Arena.Snake.Direction != 2) {

            this.Arena.Snake.Direction = 1;
        } 
        else if (e.key == "ArrowLeft" && this.Arena.Snake.Direction != 1 && this.Arena.Snake.Direction != 2) {

            this.Arena.Snake.Direction = 2;
        } 
        else if (e.key == "ArrowDown" && this.Arena.Snake.Direction != 0 && this.Arena.Snake.Direction != 3) {

            this.Arena.Snake.Direction = 3;
        }
    },

    MoveSnake: function() {

        for (let i = 19 ; i >= 0 ; i--) {

            if (this.Arena.Snake.Tail[i].Exist && i != 0) {

                this.Arena.Snake.Tail[i].X = this.Arena.Snake.Tail[i-1].X;
                this.Arena.Snake.Tail[i].Y = this.Arena.Snake.Tail[i-1].Y;
            }
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
        ||  this.Arena.Snake.Tail[0].X > 29
        ||  this.Arena.Snake.Tail[0].Y < 0
        ||  this.Arena.Snake.Tail[0].Y > 29) {

            return true;
        }
        else {

            for (let i = 1; i < 20; i++) {

                if (this.Arena.Snake.Tail[i].Exist == true) {

                    if (this.Arena.Snake.Tail[0].X == this.Arena.Snake.Tail[i].X
                    &&  this.Arena.Snake.Tail[0].Y == this.Arena.Snake.Tail[i].Y) {

                    return true;
                    }
                }
            }
            return false;
        }
    },

    GrowUp: function() {

        if (!this.Arena.Snake.Tail[19].Exist) {

            let i = 1;
            while (this.Arena.Snake.Tail[i].Exist == true) {

                i++;
            }

            this.Arena.Snake.Tail[i].Exist = true;

            this.app.loader.load((loader, resources) => {
                    
                this.snake[i] = new PIXI.Sprite(resources.snake.texture);
                console.log(this.snake[i].x + ' : ' + this.snake[i].y );
                this.snake[i].x = this.snake[0].x;
                this.snake[i].y = this.snake[0].y;
                console.log(this.snake[i].x + ' : ' + this.snake[i].y );
                this.snake[i].width = 20;
                this.snake[i].height = 20;

                this.container.addChild(this.snake[i]);
            });
        }

        this.Score++;
        this.texte.text = "Score : " + this.Score;
    }
  }
};
</script>
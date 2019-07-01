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
      
      app: {},
      container: {},

      GameIsOn: false,
      Time: this.$route.params.Time,

      LifeTime: 0,

      Uncount: 20,
      MaxUncount: 20,
      uncount: {},

      question: {},
      ImQ: {},
      answer1: {},
      ImA1: {},
      answer2: {},
      ImA2: {},
      answer3: {},
      ImA3: {},
      answer4: {},
      ImA4: {},

      Q: "",
      R1: 0,
      R2: 0,
      R3: 0,
      R4: 0,

      Pivot: 0
    }
  },

  async mounted() {

    this.StartUp();
  },

  methods: {

    End: function() {

      this.app.ticker.stop();
      console.log("exit test");
      this.$router.replace("/EndGame/" + this.Score + "/5/" + this.Time + "/" + this.$route.params.id);
      this.GameIsOn = false;
    },

    StartUp: function() {

      this.Score = 0;
      this.GameIsOn = true;

      this.app = new PIXI.Application({
        width: 600,
        height: 600, 
        backgroundColor: 0x4400c3, 
        resolution: window.devicePixelRatio || 1,
      });

      document.querySelector("#Game").appendChild(this.app.view);

      this.container = new PIXI.Container();

      this.app.loader.add('question', '/Math/question.jpg');

      this.app.loader.add('answer', '/Math/answer.jpg');

      let style0 = new PIXI.TextStyle({
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

      let style1 = new PIXI.TextStyle({
        fontFamily: "Arial",
        fontSize: 25,
        fill: "black",
        stroke: '#00c0c3',
        strokeThickness: 4,
        dropShadow: true,
        dropShadowColor: "#000000",
        dropShadowBlur: 4,
        dropShadowAngle: Math.PI / 6,
        dropShadowDistance: 6,
      });

      let style2 = new PIXI.TextStyle({
        fontFamily: "Arial",
        fontSize: 25,
        fill: "white",
        stroke: '#00c0c3',
        strokeThickness: 4,
        dropShadow: true,
        dropShadowColor: "#000000",
        dropShadowBlur: 4,
        dropShadowAngle: Math.PI / 6,
        dropShadowDistance: 6,
      });

      this.app.loader.load((loader, resources) => {

        this.ImQ = new PIXI.Sprite(resources.question.texture);

        // this.ImQ.width = 20;
        // this.ImQ.height = 20;
        this.ImQ.x = 125;
        this.ImQ.y = 80;

        this.ImA1 = new PIXI.Sprite(resources.answer.texture);

        // this.ImA1.width = 20;
        // this.ImA1.height = 20;
        this.ImA1.x = 20;
        this.ImA1.y = 230;
        this.ImA1.interactive = true;
        this.ImA1
                  .on('mousedown', this.Match1)

        this.ImA2 = new PIXI.Sprite(resources.answer.texture);

        // this.ImA2.width = 20;
        // this.ImA2.height = 20;
        this.ImA2.x = 120;
        this.ImA2.y = 400;
        this.ImA2.interactive = true;
        this.ImA2
                  .on('mousedown', this.Match2)

        this.ImA3 = new PIXI.Sprite(resources.answer.texture);

        // this.ImA3.width = 20;
        // this.ImA3.height = 20;
        this.ImA3.x = 320;
        this.ImA3.y = 400;
        this.ImA3.interactive = true;
        this.ImA3
                  .on('mousedown', this.Match3)

        this.ImA4 = new PIXI.Sprite(resources.answer.texture);

        // this.ImA4.width = 20;
        // this.ImA4.height = 20;
        this.ImA4.x = 415;
        this.ImA4.y = 230;
        this.ImA4.interactive = true;
        this.ImA4
                  .on('mousedown', this.Match4)

        this.container.addChild(this.ImQ);
        this.container.addChild(this.ImA1);
        this.container.addChild(this.ImA2);
        this.container.addChild(this.ImA3);
        this.container.addChild(this.ImA4);

        this.uncount = new PIXI.Text(this.Uncount, style0);
        this.uncount.position.set(562, 0);

        this.app.stage.addChild(this.uncount);

        this.question = new PIXI.Text("Calcul : ", style2);
        this.question.position.set(215, 127);

        this.app.stage.addChild(this.question);

        this.answer1 = new PIXI.Text("Calcul : ", style1);
        this.answer1.position.set(85, 290);

        this.app.stage.addChild(this.answer1);

        this.answer2 = new PIXI.Text("Calcul : ", style1);
        this.answer2.position.set(185, 460);

        this.app.stage.addChild(this.answer2);

        this.answer3 = new PIXI.Text("Calcul : ", style1);
        this.answer3.position.set(385, 460);

        this.app.stage.addChild(this.answer3);

        this.answer4 = new PIXI.Text("Calcul : ", style1);
        this.answer4.position.set(485, 290);

        this.app.stage.addChild(this.answer4);

        this.score = new PIXI.Text("Score : " + this.Score + " pts", style0);
        this.score.position.set(10, 560);

        this.app.stage.addChild(this.score);

        this.app.stage.addChild(this.container);
        this.app.stage.setChildIndex(this.container);

        this.app.renderer.render(this.app.stage);

        this.NewQR();

        this.app.ticker.add(delta => this.GameLoop(delta));
      });
    },

    GameLoop: function(delta) {

      this.LifeTime++;
      this.score.text = "Score : " + this.Score + " pts";
      this.uncount.text = this.Uncount;
      //console.log(this.LifeTime);
      this.question.text = "Calcul : " + this.Q;
      this.answer1.text = this.R1;
      this.answer2.text = this.R2;
      this.answer3.text = this.R3;
      this.answer4.text = this.R4;

      if (this.LifeTime > 60) {

        this.LifeTime = 0;
        if (this.Uncount > -1) 
        {
          this.Uncount--;
          console.log(this.Uncount);
        }
        this.uncount.text = this.Uncount;

        if (this.Uncount < 0) {

          this.End();
        }
      }
    },

    Match1: function() {

      console.log("Click : " + 1);

      if (this.Pivot == 1) {

        this.Score++;
        this.MaxUncount--;
        this.Uncount = this.MaxUncount;
        this.LifeTime = 0;
        this.NewQR();
      }
      else {

        this.End();
      }
    },

    Match2: function() {

      console.log("Click : " + 2);

      if (this.Pivot == 2) {

        this.Score++;
        this.MaxUncount--;
        this.Uncount = this.MaxUncount;
        this.LifeTime = 0;
        this.NewQR();
      }
      else {

        this.End();
      }
    },

    Match3: function() {

      console.log("Click : " + 3);

      if (this.Pivot == 3) {

        this.Score++;
        this.MaxUncount--;
        this.Uncount = this.MaxUncount;
        this.LifeTime = 0;
        this.NewQR();
      }
      else {

        this.End();
      }
    },

    Match4: function() {

      console.log("Click : " + 4);

      if (this.Pivot == 4) {

        this.Score++;
        this.MaxUncount--;
        this.Uncount = this.MaxUncount;
        this.LifeTime = 0;
        this.NewQR();
      }
      else {

        this.End();
      }
    },

    NewQR: function() {

      let x;
      let y;
      let z;

      x = Math.floor(Math.random()*8) + 2;
      y = Math.floor(Math.random()*8) + 2;
      z = x * y;

      this.Pivot = Math.floor(Math.random()*3) + 1;

      this.Q = x + " x " + y + " ?";

      if (this.Pivot == 1) {

        this.R1 = z;
        this.R2 = Math.floor(Math.random()*99) + 1;
        this.R3 = Math.floor(Math.random()*99) + 1;
        this.R4 = Math.floor(Math.random()*99) + 1;

        if (this.R2 == this.R1) {

          this.R2++;
        }
        if (this.R3 == this.R1) {

          this.R3--;
        }
        if (this.R4 == this.R1) {

          this.R4 += 2;
        }
      }
      else if (this.Pivot == 2) {

        this.R1 = Math.floor(Math.random()*99) + 1;
        this.R2 = z;
        this.R3 = Math.floor(Math.random()*99) + 1;
        this.R4 = Math.floor(Math.random()*99) + 1;

        if (this.R1 == this.R2) {

          this.R1++;
        }
        if (this.R3 == this.R2) {

          this.R3--;
        }
        if (this.R4 == this.R2) {

          this.R4 += 2;
        }
      }
      else if (this.Pivot == 3) {

        this.R1 = Math.floor(Math.random()*99) + 1;
        this.R2 = Math.floor(Math.random()*99) + 1;
        this.R3 = z;
        this.R4 = Math.floor(Math.random()*99) + 1;

        if (this.R2 == this.R3) {

          this.R2++;
        }
        if (this.R1 == this.R3) {

          this.R1--;
        }
        if (this.R4 == this.R3) {

          this.R4 += 2;
        }
      }
      else if (this.Pivot == 4) {

        this.R1 = Math.floor(Math.random()*99) + 1;
        this.R2 = Math.floor(Math.random()*99) + 1;
        this.R3 = Math.floor(Math.random()*99) + 1;
        this.R4 = z;

        if (this.R2 == this.R4) {

          this.R2++;
        }
        if (this.R3 == this.R4) {

          this.R3--;
        }
        if (this.R1 == this.R4) {

          this.R1 += 2;
        }
      }
    }
  }
};
</script>
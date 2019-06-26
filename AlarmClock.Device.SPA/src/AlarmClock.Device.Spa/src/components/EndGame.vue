<template>
    <div id='Screen'>
        <audio controls autoplay="autoplay" style="display:none" id="myAudio" loop>
          <source :src="Name + Time" type="audio/mpeg">
        </audio>
    </div>
</template>

<script>
import * as PIXI from 'pixi.js';
import VueCastProps from 'vue-cast-props';
import vue from 'vue';

export default {
  computed: {
  },
  data() {

    return {

      Score: this.$route.params.Score,
      app: {},
      Limite: this.$route.params.Limite,
      ImButton: {},
      ImButtonDown: {},
      Button: {},
      Name: "../../../Pharell Williams - Happy.mp3",
      Time: "#t=00:00:" + this.$route.params.Time,
      GameName: "Math"
    }
  },

  mounted() {
      this.StartUp();
  },

  methods: {

      StartUp() {

        if (Number(this.Score) < Number(this.Limite)) {
            this.app = new PIXI.Application({
                width: 400,
                height: 400, 
                backgroundColor: 0x990000, 
                resolution: window.devicePixelRatio || 1,
            });

            let style = new PIXI.TextStyle({
                fontFamily: "Arial",
                fontSize: 25,
                fill: "white",
                stroke: '#00ff83',
                strokeThickness: 4,
                dropShadow: true,
                dropShadowColor: "#000000",
                dropShadowBlur: 4,
                dropShadowAngle: Math.PI / 6,
                dropShadowDistance: 6,
            });

            this.texte = new PIXI.Text("LOOSE : " + this.Score + " Points", style);

            this.app.loader.add('ImButton', '/endGame/rejouer2.png');
          this.app.loader.add('ImButtonDown', '/endGame/rejouer1.png');

          this.app.loader.load((loader, resources) => {

            this.ImButton = new PIXI.Sprite(resources.ImButton.texture);

            this.ImButtonDown = new PIXI.Sprite(resources.ImButtonDown.texture);

            this.container = new PIXI.Container();

            this.Button = this.ImButton;

            this.Button.anchor.set(0.5);

            this.Button.position.x = 200;
            this.Button.position.y = 300;
            this.Button.position.z = 0;
            this.Button.width = 150;
            this.Button.height = 150;

            this.Button.interactive = true;

            this.Button
                  .on('mousedown', this.onButtonDown)
                  .on('touchstart', this.onButtonDown)
                  .on('mouseup', this.Replay)
                  .on('touchend', this.Replay)
                  .on('mouseupoutside', this.Replay)
                  .on('touchendoutside', this.Replay)

            this.container.addChild(this.Button);

            document.querySelector("#Screen").appendChild(this.app.view);


            this.texte.position.set(100, 120);
            this.app.stage.addChild(this.texte);

            this.app.stage.addChild(this.container);

            this.app.renderer.render(this.app.stage);
          });
        }
        else
        {
          this.app = new PIXI.Application({
              width: 400,
              height: 400, 
              backgroundColor: 0x38761D, 
              resolution: window.devicePixelRatio || 1,
          });

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

          this.texte = new PIXI.Text("WIN : " + this.Score + " Points", style);

          this.app.loader.add('ImButton', '/endGame/retour2.png');
          this.app.loader.add('ImButtonDown', '/endGame/retour1.png');

          this.app.loader.load((loader, resources) => {

            this.ImButton = new PIXI.Sprite(resources.ImButton.texture);

            this.ImButtonDown = new PIXI.Sprite(resources.ImButtonDown.texture);

            this.container = new PIXI.Container();

            this.Button = this.ImButton;

            this.Button.anchor.set(0.5);

            this.Button.position.x = 200;
            this.Button.position.y = 300;
            this.Button.width = 150;
            this.Button.height = 150;

            this.Button.interactive = true;

            this.Button
                  .on('mousedown', this.onButtonDown)
                  .on('touchstart', this.onButtonDown)
                  .on('mouseup', this.GoClock)
                  .on('touchend', this.GoClock)
                  .on('mouseupoutside', this.GoClock)
                  .on('touchendoutside', this.GoClock)

            this.container.addChild(this.Button);

            document.querySelector("#Screen").appendChild(this.app.view);


            this.texte.position.set(110, 120);
            this.app.stage.addChild(this.texte);

            this.app.stage.addChild(this.container);

            this.app.renderer.render(this.app.stage);
          });
        }

      },

      onButtonDown()
      {
        console.log("onButtonDown");
        this.isdown = true;
        this.Button = this.ImButtonDown;
      },

      Replay() {
        console.log("Replay");
        
        this.EndTime = document.getElementById("myAudio").currentTime.toFixed(2);
        if (this.EndTime < 10) {

          this.EndTime = "0" + this.EndTime;
        }
        var temp = this.EndTime.split(".");
        this.EndTime = temp[0];
        this.$router.replace("/" + this.GameName + "/" + this.EndTime);
      },

      GoClock() {
        console.log("GoClock");

        this.$router.replace("/");
      }
  }
};
</script>
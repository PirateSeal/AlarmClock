<template>
    <div id='Screen'>
        <div v-if="this.Score < 10"><button v-on:click="Replay()">Rejouer</button></div>
        <div v-else><button v-on:click="GoClock()">Retour au Réveil</button></div>
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

      Score: this.$route.params.Score,
      app,
      Limite: this.$route.params.Limite
    }
  },

  mounted() {
      this.StartUp();
  },

  methods: {

      StartUp() {

        if (this.Score < this.Limite) {
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
        }

        document.querySelector("#Screen").appendChild(this.app.view);

        this.container = new PIXI.Container();


        this.texte.position.set(105, 180);
        this.app.stage.addChild(this.texte);

        this.app.renderer.render(this.app.stage);
      },

      Replay() {

        this.$router.replace("/Snake");
      },

      GoClock() {

        this.$router.replace("/MainMenu");
      }
  }
};
</script>
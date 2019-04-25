<template>
    <form @submit="onSubmit($event)">
        
        <div class="box-horizon" margin-right: 40px>
            <div class="box-vertical">

                <label class="required">Nom</label>
                <input type="text" v-model="preset.Name" value="preset.Name" class="form-control" required>

                <label class="required">Heure</label>
                <input type="time" v-model="preset.Hour" value="preset.Hour" class="form-control" required>

            </div>

            <label class="required">Days</label>

            <div class="box-vertical">

                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[0]" value="1">Sunday</div>
                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[1]" value="1">Monday</div>
                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[2]" value="1">Tuesday</div>
                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[3]" value="1">Wednesday</div>
                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[4]" value="1">Thursday</div>
                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[5]" value="1">Friday</div>
                <div class="box-horizon"><input type="checkbox" v-model="preset.Days[6]" value="1">Saturday</div>

            </div>
        </div><br>

        <button type="submit" class="btn btn-primary">Sauvegarder</button>
        
    </form>
</template>

<script>

    export default {

        data () {
            return {
                preset: {
                    Name:"Test",
                    Hour:"13:35",
                    Days: ["1","0","0","1","0","1","0"]
                },
                mode: null,
                errors: []
            }
        },

        async mounted() {
        },

        methods: {
            async onSubmit(event) {
                event.preventDefault();
                
                var errors = [];

                if(!this.preset.Name) errors.push("Name")
                if(!this.preset.Hour) errors.push("Hour")
                if(!this.preset.Days) errors.push("Days")

                this.errors = errors;

                if(errors.length == 0) {
                    try {
                        if(this.mode === 'edit') await updateStudentAsync(this.preset);
                        else await createStudentAsync(this.preset);
                        this.$router.replace('');
                    }
                    catch(e) {
                        console.error(e);
                    }
                }
            }
        }
    }
</script>

<style lang="scss">

input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=checkbox], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=time], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

input[type=submit] {
  width: 100%;
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type=submit]:hover {
  background-color: #45a049;
}


.box-horizon {
    display: flex;
    writing-mode: horizontal-tb;
}

.box-vertical {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(300px, auto));
}

</style>
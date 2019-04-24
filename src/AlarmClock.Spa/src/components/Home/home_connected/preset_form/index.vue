<template>
    <form @submit="onSubmit($event)">
        
        <div>
            <label class="required">Nom</label>
            <input type="text" v-model="preset.Name" value="preset.Name" class="form-control" required>
        </div>

        <div>
            <label class="required">Heure</label>
            <input type="time" v-model="preset.Hour" value="preset.Hour" class="form-control" required>
        </div>
        <div>
            <label class="required">Days</label>
            <input type="checkbox" v-model="preset.Days[0]" value="1" (v-if="preset.Days[0]=1" checked) class="form-control">Sunday
            <input type="checkbox" v-model="preset.Days[1]" value="1" (v-if="preset.Days[1]=1" checked) class="form-control">Monday
            <input type="checkbox" v-model="preset.Days[2]" value="1" (v-if="preset.Days[2]=1" checked) class="form-control">Tuesday
            <input type="checkbox" v-model="preset.Days[3]" value="1" (v-if="preset.Days[3]=1" checked) class="form-control">Wednesday
            <input type="checkbox" v-model="preset.Days[4]" value="1" (v-if="preset.Days[4]=1" checked) class="form-control">Thursday
            <input type="checkbox" v-model="preset.Days[5]" value="1" (v-if="preset.Days[5]=1" checked) class="form-control">Friday
            <input type="checkbox" v-model="preset.Days[6]" value="1" (v-if="preset.Days[6]=1" checked) class="form-control">Saturday
        </div>

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


</style>
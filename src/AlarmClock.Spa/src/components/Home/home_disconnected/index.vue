<template>
  <div class="home_disconnected">
    <div class="title">
      <div class="Logo"></div>
    </div>
  </div>
</template>

<script>

export default {
  name: "home_disconnected_index",
  data() {
    return {
    endpoint: null

    };
  }
};
</script>
<style lang="scss" scoped>
.Logo{
    background: url("~/assets/logo.svg");
    background-repeat: no-repeat;
    background-size: 100%;
    height: 500px;
    width: 500px;
   border-radius: 10px;
}

.home_disconnected {
	background-size: 400% 400%;
	-webkit-animation: Gradient 15s ease-out ;
	-moz-animation: Gradient 15s ease-out;
	animation: Gradient 15s ease-out ;
}

@-webkit-keyframes Gradient {
	0% {	
	background-position: 100% 50%
	}
	50% {
		background-position: 0% 50%
	}
	100% {
		background-position: 0% 50%
	}
}

@-moz-keyframes Gradient {
	0% {
		background-position: 100% 50%

	}
	50% {
		background-position: 0% 50%
	}
	100% {
		background-position: 0% 50%
	}
}

@keyframes Gradient {
	0% {
    	background-position: 100% 50%
	}
	50% {
		background-position: 0% 50%
	
	}
	100% {
		background-position: 0% 50%
	}
}
</style>

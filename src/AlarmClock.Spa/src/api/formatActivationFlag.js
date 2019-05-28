export function formatActivationFlag(flag) {
   
  let flagArray = [];
  for(let i = 2 ; i<= 255 ; i = i<< 1)
    {
      if((flag & i) !== 0 ){
        flagArray.push(true)
      }
      else{       
        flagArray.push(false)
      }
    }
   if((flag&1) != 0) flagArray.push(true);
   else flagArray.push(false); 
  return flagArray;
}

export function reformActivationFlag(flagArray) {
  var j = 7;
  var flag = 0;

  for( var i = 0 ; i < 8 ; i++ & j--) {
    if(flagArray[i] == true) { flag += ( Math.pow(2, j))}
  }

  return flag;
}
function Func(){
var someMath=document.getElementById("field").value;
function Calculate(){
   var methods = {
        "+": function(a,b){
            return a+b;
        },
        "-": function(a,b){
            return a-b;
        },
        "*": function(a,b){
            return a*b;
        },
        "/": function(a,b){
            return a/b;
        }
    };
    var littleAct ="/((?:^[+\-]?\s?)\d+(?:\.\d+)?)\s?([+\-*\/])\s?(\d+(?:\.\d+)?)/";
    this.calc=function(str){
        var a;
        var b;
        var op;
        var result=NaN;
          while(true){
            var find = str.match(/((?:^[+\-]?\s?)\d+(?:\.\d+)?)\s?([+\-*\/])\s?(\d+(?:\.\d+)?)/);
            if(find==null){
               return result;
            }
            a = +find[1];
            b = +find[3];
            op = find[2];
            result = methods[op](a,b); 
            str = str.replace(find[0], result);
            }
    }
}
   var c = new Calculate;
   if(someMath.match(/(\d+(?:\.\d+)?\s?=)$\s?/)==null){
       alert(NaN);
   }else{
    var res = c.calc(someMath);
    alert(res.toFixed(2));
   }
  
}

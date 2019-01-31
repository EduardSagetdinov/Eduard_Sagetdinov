function Func(){
var a = document.getElementById("some_text").value;
var old_str = a.split(" ");
var delete_this = {};

for(var i=0; i<old_str.length; i++){
    var word = old_str[i].toLowerCase().split("");
    for(var j=0; j<word.length;j++){
       if(word.indexOf(word[j])!=word.lastIndexOf(word[j])){
            delete_this[word[j]]=true;
           
       }
    }
   
}
var keys = Object.keys(delete_this);
var l="";
for(var b=0; b<a.length;b++){
    if(keys.indexOf(a[b].toLowerCase())==-1){
        l+=a[b];
    }
}
alert("After removing dublicate chars:\n"+l);
}
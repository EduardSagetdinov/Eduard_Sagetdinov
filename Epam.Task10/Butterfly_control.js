var activeLi;
var clickedButton;
var clickedLi;
var count=0;
var tut = {};
var someLi = document.getElementsByTagName('li');
var someButton = document.getElementsByTagName('button');
tut['upPanel'] = count;

function changeBg(e){
	if(activeLi !== undefined){
        activeLi.style.backgroundColor = '';
    }
    activeLi = e.target;
	this.style.backgroundColor = '#a3c8f5';
}

function whatClicked(e){
   clickedButton = e.target;
}

for(var i=0; i<someLi.length;i++){
    someLi[i].addEventListener('click', changeBg);
    clickedLi = someLi[i].addEventListener('click', whatClicked);
}

for(var j=0; j<someButton.length; j++){
    clickedButton = someButton[j].addEventListener('click', whatClicked);
    someButton[j].addEventListener('click', mover);
}

function sayError(a){
    alert(a);
}

function mover(e){
    var f = tut[e.target.parentElement.parentElement.id];
    if(clickedButton.className == 'allToLeft'){
        var test = document.getElementsByClassName('selectedUl')[f].getElementsByTagName('li');
        var test1 = document.getElementsByClassName('availableUl')[f];
        for(var h=test.length-1; h>=0; h--){
        test1.appendChild(test[h]);
        }
    }

    if(clickedButton.className == 'allToRight'){
        var test = document.getElementsByClassName('availableUl')[f].getElementsByTagName('li');
        var test1 = document.getElementsByClassName('selectedUl')[f];
        for(var h=test.length-1; h>=0; h--){
        test1.appendChild(test[h]);
        }
    }

    if(clickedButton.className == 'oneToRight'){
        if((activeLi == undefined) || (activeLi.parentElement.className !=='availableUl')){
           sayError("You must click to some element at Available block!");
       }else{
           var whatMove = activeLi;
           var whereMove = document.getElementsByClassName('selectedUl')[f];
           whereMove.appendChild(whatMove);
       }
    }

    if(clickedButton.className == 'oneToLeft'){
        if((activeLi == undefined) || (activeLi.parentElement.className !=='selectedUl')){
           sayError("You must click to some element at Selected block!");
       }else{
           var whatMove = activeLi;
           var whereMove = document.getElementsByClassName('availableUl')[f];
           whereMove.appendChild(whatMove);
       }
    }

    if(clickedButton.className == 'clone'){
        ++count;
        someLi = document.getElementsByTagName('li');
        someButton = document.getElementsByTagName('button');
        var allPanel = document.getElementById('upPanel');
        var newPanel = allPanel.cloneNode(true);
        newPanel.id = newPanel.id+count
        tut[newPanel.id]=count;
        document.body.appendChild(newPanel);
        function changeBg(e){
            if(activeLi !== undefined){
                activeLi.style.backgroundColor = '';
            }
            activeLi = e.target;
            this.style.backgroundColor = '#a3c8f5';
        }
        
        function whatClicked(e){
           clickedButton = e.target;
        }
        
        for(var i=0; i<someLi.length;i++){
            someLi[i].addEventListener('click', changeBg);
            clickedLi = someLi[i].addEventListener('click', whatClicked);
        }
        
        for(var j=0; j<someButton.length; j++){
            clickedButton = someButton[j].addEventListener('click', whatClicked);
            someButton[j].addEventListener('click', mover);
        }
    }
}
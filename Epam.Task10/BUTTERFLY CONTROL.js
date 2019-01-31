"use strict";

(function () {
    var selectedClass = "selectedClass";
    window.onload = function () {
        upPanel.onclick = moveToFrom;
        downPanel.onclick = moveToFrom;
    }
    function moveToFrom(event) {
        if (event.target.tagName == "LI") {
            event.target.classList.toggle(selectedClass);
        }

        if (event.target.className == "allToRight") {
            allCopy(this,"allToRight");
        }

        if (event.target.className == "allToLeft") {
            allCopy(this, "allToLeft");
        }

        if (event.target.className == "oneToRight") {
            copySelected(this, "oneToRight");
        }

        if (event.target.className == "oneToLeft") {
            copySelected(this, "oneToLeft");
        }
    }
    function copySelected(objOfEvent, from) {
        var fromUl = "availableUl";
        var toUl = "selectedUl";

        if (from == "oneToLeft") {
            fromUl = "selectedUl";
            toUl = "availableUl";
        }
        else if (from != "oneToLeft") {
            return;
        }

        var whatToCopyUl = objOfEvent.getElementsByClassName(fromUl)[0];
        var allToCopyLi = whatToCopyUl.getElementsByTagName("li");
        var toCopyLi=[];
        var counter = 0;
        for (var i = 0; i < allToCopyLi.length; i++) {
            if (allToCopyLi[i].classList.contains(selectedClass)) {
                toCopyLi[counter] = allToCopyLi[i];
                counter++;
            }
        }
        if (counter==0) {
            var mistake = "You haven't chosen anything in \"Available\" area";
            if (fromUl == "selectedUl") {
                mistake = "You haven't chosen anything in \"Selected\" area";
            }
            alert(mistake);
            return;
        }

        var whereToCopyUl = objOfEvent.getElementsByClassName(toUl)[0];
        var copyToCopyLi = [];
        var numberOfLi = toCopyLi.length;
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i] = toCopyLi[i];
        }
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i].classList.remove(selectedClass);
            whereToCopyUl.appendChild(copyToCopyLi[i]);
        }
    }
    function allCopy(objOfEvent, from) {
        var fromUl = "availableUl";
        var toUl = "selectedUl";

        if (from == "allToLeft") {
            fromUl = "selectedUl";
            toUl = "availableUl";
        }
        else if (from != "allToRight") {
            return;
        }

        var whatToCopyUl = objOfEvent.getElementsByClassName(fromUl)[0];
        var toCopyLi = whatToCopyUl.getElementsByTagName("li");
        var whereToCopyUl = objOfEvent.getElementsByClassName(toUl)[0];
        var copyToCopyLi = [];
        var numberOfLi = toCopyLi.length;
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i] = toCopyLi[i];
        }
        for (var i = 0; i < numberOfLi; i++) {
            copyToCopyLi[i].classList.remove(selectedClass);
            whereToCopyUl.appendChild(copyToCopyLi[i]);
        }
    }

    
    
})()
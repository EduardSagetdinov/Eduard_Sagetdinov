"use strict";

(function () {

    var srcs = [
        "https://www.yandex.ru/",
        "https://www.google.com/",
        "https://https://pikabu.ru/",
               ]

    var TIME_CONST_S = 5;
    var numberOfPage = 0;
    var numberOfSeconds = TIME_CONST_S;
    var showPagesTime;
    var showTime;
    var gallery;

    window.onload = function () {
        gallery = window.open(srcs[numberOfPage]);
        showPagesTime = setInterval(showPages, (TIME_CONST_S + 1) * 1000);
        showTimer();
        showTime = setInterval(showTimer, 1000);
        reset.onclick = resetTimers;
        prev.onclick = goToPreviosPage;
        next.onclick = goToNextPage;
    }

    function showPages() {
        numberOfPage++;
        if (numberOfPage > srcs.length - 1) {
            var answerFromUser = confirm("Restart- ok. Exit-cancel.");
            if (answerFromUser) {
                numberOfPage = 0;
            }
            else {
                clearInterval(showTime);
                clearInterval(showPagesTime);
                gallery.close();
                return;
            }
        }

        gallery.location.replace(srcs[numberOfPage]);
        clearInterval(showTime);
        numberOfSeconds = TIME_CONST_S;
        showTimer();
        showTime = setInterval(showTimer, 1000);
    }

    function showTimer() {
        timer.innerText = numberOfSeconds;
        numberOfSeconds--;
    }

    function resetTimers() {
        clearInterval(showTime);
        clearInterval(showPagesTime);
        numberOfSeconds = TIME_CONST_S;
        showTimer();
        showPagesTime = setInterval(showPages, (TIME_CONST_S + 1) * 1000);
        showTime = setInterval(showTimer, 1000);
    }

    function goToPreviosPage() {
        if (numberOfPage == 0) {
            return;
        }
        numberOfPage -= 2;
        showPages();
        resetTimers();
    }

    function goToNextPage() {
        if (numberOfPage == srcs.length - 1) {
            return;
        }
        showPages();
        resetTimers();
    }



})()
window.ehzBlazorUx = {
    playAudioFile: (src) => {
        new Audio(src).play();
    },
    transitionFunction: function (back) {

        let transitionIn = document.getElementsByClassName('transition-in')[0];
        let transitionOut = document.getElementsByClassName('transition-out')[0];

        let direction = back ? "Up" : "Down";
        direction = "";

        if (transitionIn && transitionOut) {
            const handle_transitionOut_onanimationend = () => {
                console.log('Transition ended');
                transitionOut.removeEventListener("animationend", handle_transitionOut_onanimationend);
                transitionOut.classList.remove("transitioning");
                if (transitionOut.classList.contains(
                    "transition__out"
                )) {
                    transitionOut.classList.add('transition-display-none');
                }
                if (transitionOut.classList.contains(
                    "transition__in"
                )) {
                    transitionOut.classList.remove('transition-display-none');
                }
            };
            const handle_transitionOut_onanimationcancel = () => {
                console.log('Animation Cancel');
                transitionOut.removeEventListener("animationend", handle_transitionOut_onanimationend);
                transitionOut.removeEventListener("animationcancel", handle_transitionOut_onanimationcancel);
            };
            transitionOut.addEventListener('animationend', handle_transitionOut_onanimationend);
            transitionOut.addEventListener('animationcancel', handle_transitionOut_onanimationcancel);

            transitionOut.classList.remove('transition-out');
            transitionOut.classList.remove('transition-display-none');
            transitionOut.classList.add(
                "transition__out",
                "animate__zoomOut" + direction,
                //"animate__faster",
                "animate__slow",
                "animate__animated"
            );

            const handle_transitionIn_onanimationend = () => {
                console.log('Animation ended');
                transitionIn.removeEventListener("animationend", handle_transitionIn_onanimationend);
                if (transitionIn.classList.contains(
                    "transition__in"
                )) {
                    transitionIn.classList.remove('transition-display-none');
                }
                if (transitionIn.classList.contains(
                    "transition__out"
                )) {
                    transitionIn.classList.add('transition-display-none');
                }
            };
            const handle_transitionIn_onanimationcancel = () => {
                console.log('Animation Cancel');
                transitionIn.removeEventListener("animationend", handle_transitionIn_onanimationend);
                transitionIn.removeEventListener("animationcancel", handle_transitionIn_onanimationcancel);
            };
            transitionIn.addEventListener('animationend', handle_transitionIn_onanimationend);
            transitionIn.addEventListener('animationcancel', handle_transitionIn_onanimationcancel);

            transitionIn.classList.remove('transition-in');
            transitionIn.classList.add(
                "transition__in",
                "animate__zoomIn" + direction,
                //"animate__faster",
                //"animate__delay-1s",
                "animate__animated"
            );
        }
    }
}
window.ehzBlazorUx = {
    updateTheme: (theme) => {
        const root = document.documentElement;
        for (var key in theme) {
            root.style.setProperty(key, theme[key]);
        }
    },
    playAudioFile: (src) => {
        new Audio(src).play();
    },
    transitionFunction: function (back) {
        const transitionEndDelay = 500;
        let transitionOutEndHandler = undefined;
        let transitionIn = document.getElementsByClassName('transition-in')[0];
        let transitionOut = document.getElementsByClassName('transition-out')[0];

        console.log({ transitionIn, transitionOut })

        if (transitionIn && transitionOut) {
            const handle_transitionOut_onanimationend = function (event) {
                clearTimeout(transitionOutEndHandler);
                transitionOut.removeEventListener('animationcancel', handle_transitionOut_onanimationcancel);
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
            const handle_transitionOut_onanimationcancel = function (event) {
                clearTimeout(transitionOutEndHandler);
                transitionOut.removeEventListener('animationcancel', handle_transitionOut_onanimationcancel);
            };

            transitionOut.classList.add(
                "transition__out",
                "animate__zoomOut",
                "animate__animated"
            );
            transitionOut.classList.remove('transition-out');
            transitionOut.classList.remove('transition-display-none');

            const handle_transitionIn_onanimationend = function (event) {
                transitionIn.removeEventListener("animationend", handle_transitionIn_onanimationend);
                transitionIn.removeEventListener('animationcancel', handle_transitionIn_onanimationcancel);
                transitionIn.classList.remove("transitioning");
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
            const handle_transitionIn_onanimationcancel = function (event) {
                transitionIn.removeEventListener("animationend", handle_transitionIn_onanimationend);
                transitionIn.removeEventListener('animationcancel', handle_transitionIn_onanimationcancel);
            };

            transitionIn.classList.add(
                "transition__in",
                "animate__zoomIn",
                "animate__animated"
            );
            transitionIn.classList.remove('transition-in');

            // We wait one animation frame.
            // Without it the UI thread will trigger the end / cancel of the events before they are expected.
            setTimeout(() => {
                transitionOutEndHandler = setTimeout(handle_transitionOut_onanimationend, transitionEndDelay);
                transitionOut.addEventListener('animationcancel', handle_transitionOut_onanimationcancel);

                transitionIn.addEventListener('animationend', handle_transitionIn_onanimationend);
                transitionIn.addEventListener('animationcancel', handle_transitionIn_onanimationcancel);
            }, 17 /* One animation frame is 17ms */);
        }
    }
}
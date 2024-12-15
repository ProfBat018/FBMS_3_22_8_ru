window.onload = function () {
    const ui = SwaggerUIBundle({
        url: "/swagger/v1/swagger.json",
        dom_id: "#swagger-ui",
        presets: [SwaggerUIBundle.presets.apis, SwaggerUIStandalonePreset],
        layout: "BaseLayout",
        requestInterceptor: function (request) {
            const csrfToken = localStorage.getItem("csrfToken");
            if (csrfToken) {
                request.headers["X-CSRF-Token"] = csrfToken;
            }
            return request;
        }
    });

    // Функция для добавления поля ввода CSRF токена и кнопки
    function addCsrfAuthElements() {
        const authWrapper = document.querySelector(".auth-wrapper");

        if (authWrapper && !document.getElementById("csrf-token-input")) { // Проверка, чтобы не добавлять элементы повторно
            const csrfInput = document.createElement("input");
            csrfInput.type = "text";
            csrfInput.id = "csrf-token-input";
            csrfInput.placeholder = "Введите CSRF токен";

            const csrfButton = document.createElement("button");
            csrfButton.innerText = "Authorize CSRF Token";
            csrfButton.onclick = function () {
                const csrfToken = document.getElementById("csrf-token-input").value;
                localStorage.setItem("csrfToken", csrfToken);
                alert("CSRF Token added to local storage!");
            };

            authWrapper.appendChild(csrfInput);
            authWrapper.appendChild(csrfButton);
        }
    }


    const observer = new MutationObserver(() => {
        addCsrfAuthElements();
    });

    observer.observe(document.querySelector("#swagger-ui"), { childList: true, subtree: true });
};  
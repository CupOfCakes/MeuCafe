var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
const btnContinue = document.getElementById("btnContinue");
const usernameInput = document.getElementById("username");
const emailInput = document.getElementById("email");
const passwordInput = document.getElementById("password");
btnContinue.addEventListener("click", () => __awaiter(void 0, void 0, void 0, function* () {
    const username = usernameInput.value;
    const email = emailInput.value;
    const password = passwordInput.value;
    if (!username || !email || !password) {
        alert("Preencha os dados necessarios.");
        return;
    }
    try {
        const response = yield fetch("http://localhost:5057/api/", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                username,
                email,
                password
            })
        });
        if (!response.ok) {
            throw new Error("Erro 500");
        }
        const data = yield response.json();
        console.log("Sucesso:", data);
        alert("cadastro feito com sucesso!");
    }
    catch (error) {
        console.log("Erro:", error);
        alert("Erro indescifravel");
    }
}));
export {};
//# sourceMappingURL=SignUp.js.map
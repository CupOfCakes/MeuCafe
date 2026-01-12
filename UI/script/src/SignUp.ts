const btnContinue = document.getElementById("btnContinue") as HTMLButtonElement;
const usernameInput = document.getElementById("username") as HTMLInputElement;
const emailInput = document.getElementById("email") as HTMLInputElement;
const passwordInput = document.getElementById("password") as HTMLInputElement;

btnContinue.addEventListener("click", async () => {
    const username: string = usernameInput.value;
    const email: string = emailInput.value;
    const password: string = passwordInput.value;

    if(!username || !email || !password){
        alert("Preencha os dados necessarios.");
        return;
    }

    try{
        const response = await fetch("http://localhost:5057/api/client/CreateClient", {
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

        if(!response.ok){
            throw new Error("Erro 500");
        }

        const data = await response.json();
        console.log("Sucesso:", data);
        alert("cadastro feito com sucesso!");
    }catch(error){
        console.log("Erro:", error);
        alert("Erro indescifravel");
    }

});
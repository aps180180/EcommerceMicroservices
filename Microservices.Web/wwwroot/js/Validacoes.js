function validarNumero(input) {
    // Remove caracteres não numéricos usando expressão regular
    input.value = input.value.replace(/\D/g, '');
}
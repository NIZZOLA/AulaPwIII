// URL base da API
const API_URL = 'https://localhost:7191/api/PessoaModel';

// Carregar a lista de pessoas
async function loadPessoas() {
    const response = await fetch(API_URL); // Atualizado
    const pessoas = await response.json();
    const tableBody = document.getElementById('pessoasTableBody');
    tableBody.innerHTML = '';

    pessoas.forEach(pessoa => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${pessoa.id}</td>
            <td>${pessoa.nome}</td>
            <td>${pessoa.sobrenome}</td>
            <td>
                <button class="btn btn-info btn-sm" onclick="viewPessoa(${pessoa.id})">Detalhes</button>
                <button class="btn btn-warning btn-sm" onclick="editPessoa(${pessoa.id})">Editar</button>
                <button class="btn btn-danger btn-sm" onclick="deletePessoa(${pessoa.id})">Excluir</button>
            </td>
        `;
        tableBody.appendChild(row);
    });
}

// Abrir modal para adicionar ou editar pessoa
function openModal(mode, id = null) {
    const modal = new bootstrap.Modal(document.getElementById('pessoaModal'));
    if (mode === 'add') {
        document.getElementById('pessoaForm').reset();
        document.getElementById('id').value = '';
        modal.show();
    } else if (mode === 'edit') {
        fetchPessoaById(id).then(pessoa => {
            document.getElementById('id').value = pessoa.id;
            document.getElementById('nome').value = pessoa.nome;
            document.getElementById('sobrenome').value = pessoa.sobrenome;
            document.getElementById('dataNascimento').value = pessoa.dataNascimento;
            document.getElementById('cpf').value = pessoa.cpf;
            document.getElementById('rg').value = pessoa.rg;
            document.getElementById('endereco').value = pessoa.endereco;
            document.getElementById('numero').value = pessoa.numero;
            document.getElementById('complemento').value = pessoa.complemento;
            document.getElementById('bairro').value = pessoa.bairro;
            document.getElementById('cidade').value = pessoa.cidade;
            document.getElementById('estado').value = pessoa.estado;
            document.getElementById('cep').value = pessoa.cep;
            document.getElementById('telefone').value = pessoa.telefone;
            document.getElementById('celular').value = pessoa.celular;
            document.getElementById('email').value = pessoa.email;
            modal.show();
        });
    }
}

// Salvar pessoa (adicionar ou editar)
async function savePessoa() {
    const id = document.getElementById('id').value;
    const pessoa = {
        nome: document.getElementById('nome').value,
        sobrenome: document.getElementById('sobrenome').value,
        dataNascimento: document.getElementById('dataNascimento').value,
        cpf: document.getElementById('cpf').value,
        rg: document.getElementById('rg').value,
        endereco: document.getElementById('endereco').value,
        numero: document.getElementById('numero').value,
        complemento: document.getElementById('complemento').value,
        bairro: document.getElementById('bairro').value,
        cidade: document.getElementById('cidade').value,
        estado: document.getElementById('estado').value,
        cep: document.getElementById('cep').value,
        telefone: document.getElementById('telefone').value,
        celular: document.getElementById('celular').value,
        email: document.getElementById('email').value
    };

    const url = id ? `${API_URL}/${id}` : API_URL; // Atualizado
    const method = id ? 'PUT' : 'POST';

    const response = await fetch(url, {
        method: method,
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(pessoa)
    });

    if (response.ok) {
        loadPessoas();
        bootstrap.Modal.getInstance(document.getElementById('pessoaModal')).hide();
    }
}

// Excluir pessoa
async function deletePessoa(id) {
    if (confirm('Tem certeza que deseja excluir esta pessoa?')) {
        const response = await fetch(`${API_URL}/${id}`, { method: 'DELETE' }); // Atualizado
        if (response.ok) {
            loadPessoas();
        }
    }
}

// Ver detalhes da pessoa
async function viewPessoa(id) {
    const pessoa = await fetchPessoaById(id);
    const detalhesModalBody = document.getElementById('detalhesModalBody');
    detalhesModalBody.innerHTML = `
        <p><strong>Nome:</strong> ${pessoa.nome} ${pessoa.sobrenome}</p>
        <p><strong>CPF:</strong> ${pessoa.cpf}</p>
        <p><strong>RG:</strong> ${pessoa.rg}</p>
        <p><strong>Endereço:</strong> ${pessoa.endereco}, ${pessoa.numero}, ${pessoa.complemento}</p>
        <p><strong>Bairro:</strong> ${pessoa.bairro}</p>
        <p><strong>Cidade:</strong> ${pessoa.cidade}</p>
        <p><strong>Estado:</strong> ${pessoa.estado}</p>
        <p><strong>CEP:</strong> ${pessoa.cep}</p>
        <p><strong>Telefone:</strong> ${pessoa.telefone}</p>
        <p><strong>Celular:</strong> ${pessoa.celular}</p>
        <p><strong>Email:</strong> ${pessoa.email}</p>
    `;
    new bootstrap.Modal(document.getElementById('detalhesModal')).show();
}

// Buscar pessoa por ID
async function fetchPessoaById(id) {
    const response = await fetch(`${API_URL}/${id}`); // Atualizado
    return await response.json();
}
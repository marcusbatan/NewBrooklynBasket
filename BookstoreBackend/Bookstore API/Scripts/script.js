const uri = 'http://localhost:50536/api/BookInfo/CreateBooks';

function addBook() {
    const author = document.getElementById('author');
    const title = document.getElementById('title');
    const ISBN = document.getElementById('ISBN');


    const newTitle = {
        isComplete: false,
        name: author.value.trim()
    };

    const newAuthor = {
        isComplete: false,
        name: author.value.trim()
    };

    const newISBN = {
        isComplete: false,
        name: author.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAuthorm, newTitle, newISBN)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}
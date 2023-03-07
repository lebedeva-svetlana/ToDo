function hideNote(e) {
    let overlay = document.querySelector('.overlay');
    overlay.style.visibility = 'hidden';
    document.querySelector('.active-note-container').style.visibility = 'hidden';
    e.target.removeEventListener('click', hideNote);
}

function showNote() {
    let overlay = document.querySelector('.overlay');
    overlay.style.visibility = 'visible';
    let ActiveContainer = document.querySelector('.active-note-container');
    ActiveContainer.style.visibility = 'visible';
    overlay.addEventListener('click', hideNote);
    document.querySelector('.active-note-button.cancel-button').addEventListener('click', hideNote);
}

function showEdit(e) {
    showNote();
    let submitEdit = document.querySelector('.active-note-submit-edit');
    if (submitEdit.style.display !== 'inline') {
        let submitCreate = document.querySelector('.active-note-submit-create');
        submitCreate.style.display = 'none';
        submitEdit.style.display = 'inline';
    }
    let note = e.target.closest('.note');
    document.querySelector('.active-note-title').textContent = note.querySelector('.note-title').textContent;
    document.querySelector('.active-note-text').textContent = note.querySelector('.note-text').textContent;
    document.querySelector('.active-note-id').value = note.querySelector('.note-id').value;
}

function showAdd() {
    showNote();
    let submitCreate = document.querySelector('.active-note-submit-create');
    if (submitCreate.style.display !== 'inline') {
        let submitEdit = document.querySelector('.active-note-submit-edit');
        submitEdit.style.display = 'none';
        submitCreate.style.display = 'inline';
    }
}

document.querySelector('.add-note').addEventListener('click', showAdd);

let edits = document.querySelectorAll('.edit');

for (let i = 0; i < edits.length; ++i) {
    edits[i].addEventListener('click', showEdit);
}
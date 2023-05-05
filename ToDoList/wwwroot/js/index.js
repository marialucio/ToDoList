function addTask(event) {
  event.preventDefault();

  const input = event.target.previousElementSibling;
  const task = input.value;
  if (!task) {
    return;
  }

  const listId = event.target.closest('ul').getAttribute('data-parent-id');
  const list = document.getElementById(listId);

  const newItem = document.createElement('li');
  newItem.innerText = task;

  const button = document.createElement('button');

  button.addEventListener('click', () => { list.removeChild(newItem);});

  newItem.appendChild(button);
  
  list.insertBefore(newItem, list.lastElementChild);

  input.value = '';
}

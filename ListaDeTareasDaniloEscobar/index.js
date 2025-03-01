// Obtener elementos del DOM
const inputTarea = document.getElementById("Tarea");
const botonAgregar = document.getElementById("Agregar");
const listaTareas = document.getElementById("lista");

// Event listeners
botonAgregar.addEventListener("click", nuevaTarea);
listaTareas.addEventListener("click", accionesTarea);

//agregar una nueva tarea
function nuevaTarea() {
  const tareaTexto = inputTarea.value.trim(); 
  if (!tareaTexto) return alert("Por favor, escribe una tarea.");

  // Crear nuevo elemento de lista
  const itemTarea = document.createElement("li");
  itemTarea.textContent = tareaTexto;

  // Crear botón para eliminar tarea
  const botonBorrar = document.createElement("button");
  botonBorrar.textContent = "Eliminar";
  botonBorrar.classList.add("btnEliminar");

  // Añadir botón al item
  itemTarea.appendChild(botonBorrar);
  listaTareas.appendChild(itemTarea); // Agregar item a la lista

  inputTarea.value = ""; // Limpiar campo de texto
}

// Función para gestionar acciones de la lista (marcar o eliminar)
function accionesTarea(evento) {
  if (evento.target.classList.contains("btnEliminar")) {
    // Eliminar tarea
    evento.target.parentElement.remove();
  } else {
    // Marcar tarea como completada
    evento.target.classList.toggle("tarea-completada");
  }
}

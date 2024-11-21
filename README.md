# Totos Bakery - Gestión de Negocios

**Totos Bakery** Es una aplicación de gestión diseñada para facilitar la administración de clientes, productos, pedidos y usuarios. 
El proyecto fue desarrollado utilizando **C#** y **Windows Forms**, proporcionando una interfaz amigable y funcional.

---

## 📋 Funcionalidades Principales

### **Gestión de Clientes**
- **Agregar Cliente**: Registra nuevos clientes con sus datos personales y de contacto.
- **Editar Cliente**: Modifica la información de clientes existentes.
- **Eliminar Cliente**: Elimina registros de clientes seleccionados.
- **Cargar Clientes**: Visualiza la lista de clientes en un formato tabular.

### **Gestión de Productos**
- **Agregar Producto**: Registra nuevos productos (nombre, descripción, precio, cantidad).
- **Editar Producto**: Actualiza la información de productos registrados.
- **Eliminar Producto**: Elimina un producto de la base de datos.
- **Cargar Productos**: Muestra todos los productos en una vista tabular.

### **Gestión de Pedidos**
- **Agregar Pedido**: Crea pedidos asociando un cliente, dirección, fecha y método de pago.
- **Editar Pedido**: Permite actualizar datos de pedidos existentes.
- **Buscar Pedido**: Localiza un pedido específico por su ID.
- **Cargar Pedidos**: Muestra todos los pedidos en una tabla.

### **Gestión de Usuarios**
- **Agregar Usuario**: Crea cuentas con datos personales, nombre de usuario y privilegios.
- **Editar Usuario**: Actualiza datos de usuarios existentes.
- **Eliminar Usuario**: Elimina usuarios seleccionados de la base de datos.
- **Cargar Usuarios**: Presenta la lista completa de usuarios registrados.

---

## 🔒 Validaciones y Manejo de Errores
La aplicación implementa validaciones para garantizar la integridad de los datos:
- **Campos obligatorios**: Verifica que no queden vacíos.
- **Formato**: Valida correos electrónicos, números de teléfono y fechas.
- **Rango de valores**: Controla precios y cantidades para que sean numéricos válidos.

---

## 💾 Conexión a la Base de Datos
El proyecto utiliza una clase personalizada `ConexionBdd` para gestionar las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en la base de datos.

---

## 🖥️ Uso de DataGridView
Se implementaron vistas tabulares con **DataGridView** para facilitar la visualización de datos, asegurando una experiencia intuitiva para los usuarios.

---

## 📚 Documentación
El código está documentado utilizando comentarios XML, mejorando la legibilidad y mantenimiento del proyecto.

---

## 🚀 Tecnologías Utilizadas
- **Lenguaje**: C#
- **Framework**: Windows Forms
- **Base de Datos**: (Especificar: SQL Server, MySQL, etc.)

---

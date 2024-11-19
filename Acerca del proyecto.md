Introducción
Este proyecto consiste en una aplicación de gestión que incluye diversas funcionalidades para manejar clientes, productos, pedidos y usuarios en una base de datos. La aplicación ha sido desarrollada utilizando C# y Windows Forms, facilitando una interfaz gráfica amigable para el usuario final.

Funcionalidades Principales
Gestión de Clientes
Agregar Cliente: Permite la creación de nuevos clientes mediante un formulario donde se ingresan los datos personales y de contacto.

Editar Cliente: Facilita la modificación de la información de los clientes existentes.

Eliminar Cliente: Ofrece la opción de eliminar un cliente seleccionado de la base de datos.

Cargar Clientes: Carga y muestra la lista de clientes en un DataGridView para su visualización.

Gestión de Productos
Agregar Producto: Permite añadir nuevos productos con sus respectivas características (nombre, descripción, precio, cantidad).

Editar Producto: Facilita la edición de la información de productos ya registrados.

Eliminar Producto: Proporciona la funcionalidad para eliminar un producto seleccionado de la base de datos.

Cargar Productos: Carga y presenta la lista de productos en un DataGridView.

Gestión de Pedidos
Agregar Pedido: Permite crear nuevos pedidos asociando un cliente, ingresando la dirección de entrega, fecha y método de pago.

Editar Pedido: Facilita la modificación de los datos de pedidos existentes.

Buscar Pedido: Funcionalidad para buscar y cargar un pedido específico por su ID.

Cargar Todos los Pedidos: Carga y presenta todos los pedidos en un DataGridView.

Gestión de Usuarios
Agregar Usuario: Permite la creación de nuevos usuarios incluyendo sus datos personales, nombre de usuario, contraseña y privilegios de administrador.

Editar Usuario: Facilita la modificación de la información de usuarios registrados.

Eliminar Usuario: Proporciona la opción para eliminar un usuario seleccionado de la base de datos.

Cargar Usuarios: Carga y muestra la lista de usuarios en un DataGridView.

Validaciones y Manejo de Errores
El proyecto incluye diversas validaciones para asegurar la integridad de los datos ingresados, tales como:

Validación de campos vacíos.

Validación de formatos de correo electrónico y números de teléfono.

Validación de fechas para que no sean anteriores a la fecha actual.

Validación de precios y cantidades para que sean valores numéricos válidos.

Conexión a Base de Datos
La aplicación se conecta a una base de datos utilizando una clase de conexión (ConexionBdd) que gestiona las operaciones CRUD (Crear, Leer, Actualizar y Eliminar) para clientes, productos, pedidos y usuarios.

Uso de DataGridView
Se utiliza el control DataGridView para presentar listas de clientes, productos, pedidos y usuarios, proporcionando una vista tabular y fácil de entender para el usuario final.

Comentarios y Documentación
El código está documentado utilizando comentarios XML para describir las propiedades, métodos y eventos, mejorando así la legibilidad y mantenibilidad del código.

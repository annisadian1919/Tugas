<?php
include 'connect.php';

// ==============1===============
// Cek apakah form di-submit (tombol "update" ditekan)// ==============1===============
// If statement untuk mengecek POST request dari form
// Lalu definisikan variabel2 untuk menyimpan data yang dikirim dari POST
if (isset($_POST['update'])) {
    $id = $_POST["id"];
    $title = $_POST["title"];
    $categoryId = $_POST["category_id"];
    $author = $_POST["author"];
    $stock = $_POST["stock"];

    // ===============2===============
    // Definisikan $query untuk mengubah data menggunakan $id
    $query = "UPDATE books SET 
                title = '$title',
                category_id = '$categoryId',
                author = '$author',
                stock = '$stock'
              WHERE id = $id";

    // =============3=============
    // Eksekusi query
    if (mysqli_query($conn, $query)) {
        if (mysqli_affected_rows($conn) > 0) {
            header("Location: list_books.php");
            exit;
        } else {
            echo "
            <script>
                alert('No changes were made to the book.');
                window.location='list_books.php';
            </script>";
        }
    } else {
        echo "
        <script>
            alert('Failed to update book. Please try again.');
            window.location='list_books.php';
        </script>";
    }
}
?>

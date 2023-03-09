import { Route, Routes } from "react-router-dom";
import Home from "./components/home";
import { Button, Container, Form, Nav, Navbar } from "react-bootstrap";
import Invoice from "./components/invoice";
import { ToastContainer } from "react-toastify";
import InvoiceForm from "./components/invoice/form";

function App() {
  return (
    <>
      <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand href="#home">Xperteam - Evaluación</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="/">Inicio</Nav.Link>
              <Nav.Link href="/invoice">Facturas</Nav.Link>
            </Nav>
          </Navbar.Collapse>
          <Form className="d-flex">
            <Form.Control
              type="search"
              placeholder="Buscar"
              className="me-2"
              aria-label="Search"
            />
            <Button variant="outline-success">Buscar</Button>
          </Form>
        </Container>
      </Navbar>
      <Container className="mt-4">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/invoice" element={<Invoice />} />
          <Route path="/invoice/create" element={<InvoiceForm />} />
        </Routes>
        <ToastContainer />
      </Container>
    </>
  );
}

export default App;

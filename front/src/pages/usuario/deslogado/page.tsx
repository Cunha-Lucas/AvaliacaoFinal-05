"use client";

import { Box, Button, Container } from "@mui/material";
import { useRouter } from "next/navigation";

function Deslogado() {
  const router = useRouter();

  async function botaoVoltar(e: React.FormEvent) {
    e.preventDefault();
    router.push("/");
  }
  return (
    <div>
      <h1>Não Autenticado</h1>
      <p>Você precisa estar logado para acessar esta página.</p>
      <Container maxWidth="sm">
        <Box onSubmit={botaoVoltar}>
            <Button
              type="submit"
              variant="contained"
              color="primary"
              fullWidth
              sx={{ mt: 2 }}
            >
              Login
            </Button>
        </Box>
      </Container>
    </div>
  );
}

export default Deslogado;

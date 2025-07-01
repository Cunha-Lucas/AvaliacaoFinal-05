// src/app/layout.tsx
import { AppBar, Box, Container, CssBaseline, Toolbar, Typography } from '@mui/material';
import type { Metadata } from 'next';
import './globals.css';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

export const metadata: Metadata = {
  title: 'Projeto com MUI',
  description: 'Exemplo com AppBar e Footer usando Material UI',
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="pt-BR">
      <body>
          <CssBaseline />

          {/* Barra superior */}
          <AppBar position="static">
            <Toolbar>
              <Typography variant="h6" component="div">
                Avaliação Final
              </Typography>
            </Toolbar>
          </AppBar>

          {/* Conteúdo da página */}
          <Box component="main" sx={{ minHeight: 'calc(100vh - 120px)', py: 4 }}>
            <Container>{children}</Container>
          </Box>

          {/* Rodapé */}
          <Box component="footer" sx={{ bgcolor: '#1976d2', color: '#fff', py: 2, textAlign: 'center' }}>
            <Typography variant="body2">
              © {new Date().getFullYear()} Criado por Lucas Cunha
            </Typography>
          </Box>
      </body>
    </html>
  );
}
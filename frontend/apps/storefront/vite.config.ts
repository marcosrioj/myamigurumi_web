import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@config': '/frontend/packages/config/src',
      '@ui': '/frontend/packages/ui/src',
      '@api': '/frontend/packages/api/src'
    }
  },
  server: {
    port: 5173
  }
});

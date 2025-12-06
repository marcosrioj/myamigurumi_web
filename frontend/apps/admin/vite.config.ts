import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@config': '/frontend/packages/config/src',
      '@api': '/frontend/packages/api/src'
    }
  },
  server: {
    port: 5174
  }
});

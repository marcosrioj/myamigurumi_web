import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import path from 'node:path';

export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@config': path.resolve(__dirname, '../../packages/config/src'),
      '@api': path.resolve(__dirname, '../../packages/api/src')
    }
  },
  server: {
    port: 5174
  }
});

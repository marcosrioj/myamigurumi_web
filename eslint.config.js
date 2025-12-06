import js from '@eslint/js';
import tsPlugin from '@typescript-eslint/eslint-plugin';
import tsParser from '@typescript-eslint/parser';
import react from 'eslint-plugin-react';
import reactHooks from 'eslint-plugin-react-hooks';

export default [
  js.configs.recommended,
  {
    files: ['**/*.{ts,tsx,js,jsx}'],
    ignores: ['**/dist/**', '**/node_modules/**', '**/coverage/**', '**/bin/**', '**/obj/**'],
    languageOptions: {
      parser: tsParser,
      ecmaVersion: 'latest',
      sourceType: 'module',
      parserOptions: {
        ecmaFeatures: { jsx: true }
      }
    },
    plugins: {
      '@typescript-eslint': tsPlugin,
      react,
      'react-hooks': reactHooks
    },
    rules: {
      ...tsPlugin.configs.recommended.rules,
      ...react.configs.recommended.rules,
      'react/prop-types': 'off'
    },
    settings: {
      react: { version: 'detect' }
    }
  }
];

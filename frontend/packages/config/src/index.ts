export const apiConfig = {
  catalogBaseUrl: import.meta?.env?.VITE_CATALOG_API ?? 'http://localhost:5101',
  identityBaseUrl: import.meta?.env?.VITE_IDENTITY_API ?? 'http://localhost:5100'
};

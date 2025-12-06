module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'jsdom',
  roots: ['<rootDir>/frontend'],
  moduleNameMapper: {
    '^@config/(.*)$': '<rootDir>/frontend/packages/config/src/$1',
    '^@ui/(.*)$': '<rootDir>/frontend/packages/ui/src/$1',
    '^@api/(.*)$': '<rootDir>/frontend/packages/api/src/$1'
  }
};

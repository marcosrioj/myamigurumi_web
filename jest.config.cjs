module.exports = {
  testEnvironment: 'jsdom',
  roots: ['<rootDir>/frontend'],
  transform: {
    '^.+\\.[tj]sx?$': 'babel-jest'
  },
  moduleNameMapper: {
    '^@config/(.*)$': '<rootDir>/frontend/packages/config/src/$1',
    '^@ui/(.*)$': '<rootDir>/frontend/packages/ui/src/$1',
    '^@api/(.*)$': '<rootDir>/frontend/packages/api/src/$1'
  }
};

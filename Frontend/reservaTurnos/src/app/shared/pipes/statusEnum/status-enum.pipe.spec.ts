import { StatusEnumPipe } from './status-enum.pipe';

describe('StatusEnumPipe', () => {
  it('create an instance', () => {
    const pipe = new StatusEnumPipe();
    expect(pipe).toBeTruthy();
  });
});

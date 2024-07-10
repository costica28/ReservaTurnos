import { Pipe, PipeTransform } from '@angular/core';
import { Status } from '../../enum/status.enum';

@Pipe({
  name: 'statusEnum',
  standalone: false
})
export class StatusEnumPipe implements PipeTransform {

  transform(value: number): string {
    return Status[value];
  }

}
